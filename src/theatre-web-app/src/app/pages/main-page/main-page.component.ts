import { Component, inject } from '@angular/core';
import { EventCardComponent } from '@commom/event-card/event-card.component';
import { EventContract } from '@data/event.interface';
import { EventsService } from '@services/events/events.service.service';

@Component({
    selector: 'app-main-page',
    standalone: true,
    imports: [EventCardComponent],
    templateUrl: './main-page.component.html',
    styleUrl: './main-page.component.less',
})
export class MainPageComponent {
    eventsService = inject(EventsService);
    readonly events: EventContract[] = [];

    constructor() {
        this.events = this.eventsService.getAllEvents();
    }
}
