import { NgClass } from '@angular/common';
import { Component, EventEmitter, Input, Output } from '@angular/core';
import Event from '@data/event.interfaces';
import SeatContract, { SeatInfoModel, Sectors } from '@data/seat.interfaces';

@Component({
    selector: 'seat-selector',
    standalone: true,
    imports: [NgClass],
    templateUrl: './seat-selector.component.html',
    styleUrl: './seat-selector.component.less',
})
export class SeatSelectorComponent {
    @Input() groupedInSectorsSeats!: Sectors[];
    @Input() event!: Event;
    @Input() hallScheme!: {
        gridSchemeColumnsCount: number;
        gridSchemeRowsCount: number;
    };

    @Output() seatSelected = new EventEmitter<{
        seat: SeatContract;
        sectorNumber: number;
        rowNumber: number;
    }>();

    private occupiedSeats: SeatContract[] = [];

    getHallSchemeStyles(): string {
        return `grid-template-columns: repeat(${this.hallScheme.gridSchemeColumnsCount}, 1fr);
    grid-template-rows: repeat(${this.hallScheme.gridSchemeRowsCount}, 1fr);`;
    }

    getSeatClassByType(
        seatType: string,
        isOccupied?: boolean
    ): { class: string; name: string } {
        if (isOccupied) {
            return {
                class: 'seat',
                name: '',
            };
        }

        const standardSeatTypeDescription: { class: string; name: string } = {
            class: 'standard-seat seat',
            name: 'Стандартные',
        };

        switch (seatType.toUpperCase()) {
            case 'STANDARD':
                return standardSeatTypeDescription;
            case 'PREMIUM':
                return { class: 'premium-seat seat', name: 'Премиум' };
            case 'PAIR':
                return { class: 'pair-seat seat', name: 'Пара' };
            case 'VIP':
                return { class: 'vip-seat seat', name: 'VIP' };
            default:
                return standardSeatTypeDescription;
        }
    }

    onChooseSeat(
        seat: SeatContract,
        sectorNumber: number,
        rowNumber: number
    ): void {
        const seatToOccupy: SeatContract = seat;
        if (
            this.occupiedSeats.find(
                (occupiedSeat) => occupiedSeat.seatId === seatToOccupy.seatId
            )
        ) {
            this.occupiedSeats = this.occupiedSeats.filter(
                (occupiedSeat) => occupiedSeat.seatId !== seat.seatId
            );
            seat.isOccupied = false;
        } else {
            this.occupiedSeats.push(seatToOccupy);
            seat.isOccupied = true;
        }
        this.seatSelected.emit({ seat, sectorNumber, rowNumber });
    }
}
