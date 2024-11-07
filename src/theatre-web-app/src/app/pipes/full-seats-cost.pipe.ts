import { Pipe, PipeTransform } from '@angular/core';
import SeatContract from '@data/seat.interfaces';

@Pipe({
    name: 'fullCostPipe',
    standalone: true,
})
export class FullCostPipe implements PipeTransform {
    transform(
        seatContracts: SeatContract[],
        eventPrice: number,
        currency: string = 'BYN'
    ): string | null {
        const seatsCost = seatContracts.reduce((acc, seatContract) => {
            return (
                acc + eventPrice * seatContract.seatTypeMultiplier.multiplier
            );
        }, 0);

        return `${seatsCost} ${currency}`;
    }
}
