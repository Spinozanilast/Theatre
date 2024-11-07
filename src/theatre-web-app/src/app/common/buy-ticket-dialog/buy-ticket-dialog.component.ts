import {
    Component,
    EventEmitter,
    inject,
    Input,
    OnInit,
    Output,
} from '@angular/core';
import Event from '@data/event.interfaces';
import SeatContract, {
    SeatInfoModel,
    SeatType,
    Sectors,
} from '@data/seat.interfaces';
import { HallService as HallsService } from '@data/services/halls.service';
import SeatsService from '@data/services/seats.service';
import { BuyTicketDialogLegendComponent } from './buy-ticket-dialog-legend/buy-ticket-dialog-legend.component';
import { SeatTypeDescription } from '@data/models/dialog.models';
import { NgClass } from '@angular/common';
import { FullCostPipe } from '@pipes/full-seats-cost.pipe';
import { trigger, transition, style, animate } from '@angular/animations';
import { UserDataInputComponent } from './user-data-input/user-data-input.component';
import { SeatSelectorComponent } from './seat-selector/seat-selector.component';
import { UserService } from '@data/services/users.service';
import User, { UserData } from '@data/user.interfaces';
import { catchError, of } from 'rxjs';
import { HttpErrorResponse } from '@angular/common/http';

interface GridScheme {
    gridSchemeColumnsCount: number;
    gridSchemeRowsCount: number;
}

interface SeatToOccupy {
    seat: SeatContract;
    sectorNumber: number;
    rowNumber: number;
}

enum BuyTicketDialogStep {
    selectSeats = 'select-seats',
    buyerData = 'buyer-data',
    payment = 'payment',
}

@Component({
    selector: 'app-buy-ticket-dialog',
    standalone: true,
    imports: [
        BuyTicketDialogLegendComponent,
        NgClass,
        FullCostPipe,
        UserDataInputComponent,
        SeatSelectorComponent,
    ],
    templateUrl: './buy-ticket-dialog.component.html',
    styleUrl: './buy-ticket-dialog.component.less',
    animations: [
        trigger('appearAnimation', [
            transition(':enter', [
                style({ opacity: 0, transform: 'scale(0.5)' }),
                animate(
                    '300ms ease-in',
                    style({ opacity: 1, transform: 'scale(1)' })
                ),
            ]),
            transition(':leave', [
                animate(
                    '300ms ease-out',
                    style({ opacity: 0, transform: 'scale(0.5)' })
                ),
            ]),
        ]),
    ],
})
export class BuyTicketDialogComponent implements OnInit {
    private readonly seatsService = inject(SeatsService);
    private readonly hallService = inject(HallsService);
    private readonly userService = inject(UserService);
    // private readonly ticketService = inject(TicketService);

    @Output() close = new EventEmitter<void>();
    @Input() event!: Event;

    groupedInSectorsSeats: Sectors[] = [];
    hallScheme: GridScheme = {
        gridSchemeColumnsCount: 0,
        gridSchemeRowsCount: 0,
    };

    hallSeatTypes: Set<string> = new Set();
    occupiedSeats: SeatToOccupy[] = [];

    DialogStep = BuyTicketDialogStep;
    step: BuyTicketDialogStep = BuyTicketDialogStep.selectSeats;
    stepIdx: number = 0;

    buyerData?: User | null;

    constructor() {}

    ngOnInit(): void {
        this.initSeats();
        this.initHallScheme();
    }

    private initHallScheme(): void {
        this.hallService.getHall(this.event.hallId).subscribe((hall) => {
            this.hallScheme = {
                gridSchemeColumnsCount: hall.gridSchemeColumnsCount,
                gridSchemeRowsCount: hall.gridSchemeRowsCount,
            };
        });
    }

    private initSeats(): void {
        this.seatsService
            .getGroupedSeatsGroupedByHallId(this.event.hallId)
            .subscribe((seats) => {
                this.groupedInSectorsSeats = seats;
                this.hallSeatTypes =
                    this.seatsService.getSeatTypeMultipliersSet(
                        this.groupedInSectorsSeats
                    );
            });
    }

    /**
     * Changes the current dialog step to buy buy ticket only for visual.

     * @param step - step to change to
     */
    onChangeStep(step: BuyTicketDialogStep): void {
        this.step = step;

        if (step === BuyTicketDialogStep.buyerData) {
            this.buyerData = null;
        }
    }

    /**
     * Changes the current dialog step to buy buy ticket. Use this one to change step instead of onChangeStep.

     * @param forward - direction of changing (true - for forward and false for backward)
     */
    onChangeByStep(forward: boolean): void {
        if (this.stepIdx === Object.values(BuyTicketDialogStep).length - 1) {
            return;
        }

        if (forward) {
            this.stepIdx += 1;
        } else {
            this.stepIdx -= 1;
        }

        this.onChangeStep(Object.values(BuyTicketDialogStep)[this.stepIdx]);
    }

    onChooseSeat({ seat, sectorNumber, rowNumber }: SeatInfoModel): void {
        const seatToOccupy: SeatToOccupy = {
            seat,
            sectorNumber,
            rowNumber,
        };
        if (
            this.occupiedSeats.find(
                (occupiedSeat) =>
                    occupiedSeat.seat.seatId === seatToOccupy.seat.seatId
            )
        ) {
            this.occupiedSeats = this.occupiedSeats.filter(
                (occupiedSeat) => occupiedSeat.seat.seatId !== seat.seatId
            );
            seat.isOccupied = false;
        } else {
            this.occupiedSeats.push(seatToOccupy);
            seat.isOccupied = true;
        }
    }

    onUserDataSubmit(userData: UserData): void {
        this.userService
            .getUserByPhoneNumber(userData.phoneNumber)
            .pipe(
                catchError((error: HttpErrorResponse) => {
                    if (error.status === 404) {
                        this.createUser(userData);
                    } else {
                        console.log(
                            'Error fetching user by phone number:',
                            error
                        );
                    }
                    return of(null);
                })
            )
            .subscribe({
                next: (user) => {
                    if (user) {
                        this.buyerData = user;
                        this.onChangeByStep(true);
                    }
                },
                error: (error) => {
                    console.log('Unexpected error:', error);
                },
            });
    }

    private createUser(userData: UserData): void {
        this.userService.createUser(userData).subscribe({
            next: (newUser) => {
                this.buyerData = newUser;
                this.onChangeStep(BuyTicketDialogStep.payment);
            },
            error: () => {
                console.log(
                    'You are not new user, maybe you already have some discount'
                );
            },
        });
    }

    onCancel(): void {
        this.close.emit();
    }

    getHallSchemeStyles(): string {
        return `grid-template-columns: repeat(${this.hallScheme.gridSchemeColumnsCount}, 1fr);
        grid-template-rows: repeat(${this.hallScheme.gridSchemeRowsCount}, 1fr);`;
    }

    getSeatClassByType(
        seatType: string,
        isOccupied?: boolean
    ): SeatTypeDescription {
        if (isOccupied) {
            return {
                class: 'seat',
                name: '',
            };
        }

        const standardSeatTypeDescription: SeatTypeDescription = {
            class: 'standard-seat seat',
            name: 'Стандартные',
        };

        switch (seatType.toUpperCase()) {
            case SeatType.STANDARD:
                return standardSeatTypeDescription;
            case SeatType.PREMIUM:
                return { class: 'premium-seat seat', name: 'Премиум' };
            case SeatType.PAIR:
                return { class: 'pair-seat seat', name: 'Пара' };
            case SeatType.VIP:
                return { class: 'vip-seat seat', name: 'VIP' };
            default:
                return standardSeatTypeDescription;
        }
    }

    getSeatTypeDefinitionsByExistingTypes(): SeatTypeDescription[] {
        let seatTypes: SeatTypeDescription[] = [];
        for (const seatType of this.hallSeatTypes) {
            seatTypes.push(this.getSeatClassByType(seatType));
        }

        return seatTypes;
    }

    mapOccupiedSeatsInfoToSeatContracts(): SeatContract[] {
        return this.occupiedSeats.map((occupiedSeat) => occupiedSeat.seat);
    }
}
