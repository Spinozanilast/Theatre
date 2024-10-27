import { DatePipe } from '@angular/common';
import { Component, Input } from '@angular/core';
import { EventContract } from '@data/event.interface';
import { ImageAltPipe } from '@pipes/alt-pipe.pipe';
import { ArrayValuesSeparatorPipe } from '@pipes/array-values-separator.pipe';

@Component({
    selector: 'app-event-card',
    standalone: true,
    imports: [DatePipe, ImageAltPipe, ArrayValuesSeparatorPipe],
    templateUrl: './event-card.component.html',
    styleUrl: './event-card.component.less',
})
export class EventCardComponent {
    @Input() event!: EventContract;
}
