import { Component, inject, OnInit } from '@angular/core';
import { EventsContainerComponent } from '@commom/events/events-container/events-container.component';
import { HeaderComponent } from '@commom/header/header.component';
import { NavBarComponent } from '@commom/nav-bar/nav-bar.component';
import Event from '@data/event.interfaces';
import { EventsService } from '@data/services/events.service';

@Component({
    selector: 'app-main-page',
    standalone: true,
    imports: [EventsContainerComponent, HeaderComponent, NavBarComponent],
    templateUrl: './main-page.component.html',
    styleUrl: './main-page.component.less',
})
export class MainPageComponent implements OnInit {
    eventsService = inject(EventsService);
    events: Event[] = [];

    ngOnInit(): void {
        this.eventsService
            .getAllEvents()
            .subscribe((events) => (this.events = events));
    }
}
