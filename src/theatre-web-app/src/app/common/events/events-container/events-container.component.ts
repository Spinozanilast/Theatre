import { Component, inject } from '@angular/core';
import { EventCardComponent } from '../event-card/event-card.component';
import { BuyTicketDialogComponent } from '@commom/buy-ticket-dialog/buy-ticket-dialog.component';
import Event from '@data/event.interfaces';
import EventCardModalModel from '@data/models/event-card-model.model';
import { EventsService } from '@data/services/events.service';
import { animate, style, transition, trigger } from '@angular/animations';

@Component({
    selector: 'app-events-container',
    standalone: true,
    imports: [EventCardComponent, BuyTicketDialogComponent],
    templateUrl: './events-container.component.html',
    styleUrl: './events-container.component.less',
    animations: [
        trigger('fadeIn', [
            transition(':enter', [
                style({ opacity: 0 }),
                animate('0.5s ease-in', style({ opacity: 1 })),
            ]),
        ]),
    ],
})
export class EventsContainerComponent {
    eventsService = inject(EventsService);
    events: Event[] = [];
    selectedEvent: Event | undefined = undefined;

    isModalVisible: boolean = false;
    isLoading: boolean = true;

    constructor() {
        this.eventsService.getAllEvents().subscribe((events) => {
            this.events = events;
            this.isLoading = false;
        });
    }

    onIsModalVisibleChange(modalData: EventCardModalModel) {
        this.isModalVisible = modalData.isModalVisible;

        if (!this.isModalVisible) {
            this.selectedEvent = undefined;
        }

        this.selectedEvent = modalData.event;
        this.isModalVisible = true;
    }

    hideBuyTicketDialog() {
        this.isModalVisible = false;
        this.selectedEvent = undefined;
    }
}
