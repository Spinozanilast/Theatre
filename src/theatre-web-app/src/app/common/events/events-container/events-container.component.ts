import { Component, inject } from '@angular/core';
import { EventCardComponent } from '../event-card/event-card.component';
import { BuyTicketDialogComponent } from '@commom/buy-ticket-dialog/buy-ticket-dialog.component';
import EventContract from '@data/event.interfaces';
import EventsService from '@services/events/events.service.service';
import EventCardModalModel from '@data/models/event-card-model.model';

@Component({
    selector: 'app-events-container',
    standalone: true,
    imports: [EventCardComponent, BuyTicketDialogComponent],
    templateUrl: './events-container.component.html',
    styleUrl: './events-container.component.less',
})
export class EventsContainerComponent {
    eventsService = inject(EventsService);
    events: EventContract[] = [];
    selectedEvent: EventContract | undefined = undefined;

    isModalVisible: boolean = false;

    constructor() {
        this.eventsService
            .getAllEvents()
            .subscribe((events) => (this.events = events));
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
