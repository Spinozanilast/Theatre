import { Component, EventEmitter, Input, Output } from '@angular/core';
import EventContract from '@data/event.interfaces';

@Component({
    selector: 'app-buy-ticket-dialog',
    standalone: true,
    imports: [],
    templateUrl: './buy-ticket-dialog.component.html',
    styleUrl: './buy-ticket-dialog.component.less',
})
export class BuyTicketDialogComponent {
    @Output() close = new EventEmitter<void>();
    @Input() event!: EventContract;
    // butTicketModel?: BuyTicketModel;

    onBuyTicket() {}

    onCancel(): void {
        this.close.emit();
    }
}
