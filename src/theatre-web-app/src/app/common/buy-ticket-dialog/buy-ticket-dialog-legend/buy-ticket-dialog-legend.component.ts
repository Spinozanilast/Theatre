import { Component, Input } from '@angular/core';
import { SeatTypeDescription } from '@data/models/dialog.models';

@Component({
    selector: 'buy-ticket-dialog-legend',
    standalone: true,
    imports: [],
    templateUrl: './buy-ticket-dialog-legend.component.html',
    styleUrl: './buy-ticket-dialog-legend.component.less',
})
export class BuyTicketDialogLegendComponent {
    @Input() uniqueTypeDefinitions: SeatTypeDescription[] = [];
}
