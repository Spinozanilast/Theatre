import { DatePipe } from '@angular/common';
import { Component, EventEmitter, Input, Output } from '@angular/core';
import { BuyTicketDialogComponent } from '@commom/buy-ticket-dialog/buy-ticket-dialog.component';
import Event from '@data/event.interfaces';
import EventCardModalModel from '@data/models/event-card-model.model';
import { ImageAltPipe } from '@pipes/alt-pipe.pipe';
import { ArrayValuesSeparatorPipe } from '@pipes/array-values-separator.pipe';
import { EventTypeLocalizerPipe } from '@pipes/event-type-localizer.pipe';

@Component({
    selector: 'app-event-card',
    standalone: true,
    imports: [
        DatePipe,
        ImageAltPipe,
        ArrayValuesSeparatorPipe,
        BuyTicketDialogComponent,
        EventTypeLocalizerPipe,
    ],
    templateUrl: './event-card.component.html',
    styleUrl: './event-card.component.less',
})
export class EventCardComponent {
    @Output() isModalVisibleChange = new EventEmitter<EventCardModalModel>();
    @Input() event!: Event;
    isModalVisible = false;

    showBuyTicketDialog() {
        this.isModalVisibleChange.emit({
            isModalVisible: true,
            event: this.event,
        });
    }

    hideBuyTicketDialog() {
        this.isModalVisibleChange.emit({ isModalVisible: false });
    }
}
