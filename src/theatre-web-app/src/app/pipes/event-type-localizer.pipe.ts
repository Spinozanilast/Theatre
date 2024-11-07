import { Pipe, PipeTransform } from '@angular/core';
import { EventType } from '@data/enums/event.enums';

@Pipe({
    name: 'eventTypeLocalizer',
    standalone: true,
})
export class EventTypeLocalizerPipe implements PipeTransform {
    transform(value: string): string {
        const eventTypeKey = value as keyof typeof EventType;
        if (eventTypeKey) {
            return EventType[eventTypeKey];
        }
        return value;
    }
}
