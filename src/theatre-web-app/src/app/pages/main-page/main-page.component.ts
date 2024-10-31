import { Component, inject } from '@angular/core';
import { EventsContainerComponent } from '@commom/events/events-container/events-container.component';
import { HeaderComponent } from '@commom/header/header.component';
import EventContract from '@data/event.interfaces';
import EventsService from '@services/events/events.service.service';

@Component({
    selector: 'app-main-page',
    standalone: true,
    imports: [EventsContainerComponent, HeaderComponent],
    templateUrl: './main-page.component.html',
    styleUrl: './main-page.component.less',
})
export class MainPageComponent {
    eventsService = inject(EventsService);
    events: EventContract[] = [];

    constructor() {
        this.eventsService
            .getAllEvents()
            .subscribe((events) => (this.events = events));
    }
}
