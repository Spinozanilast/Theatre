import { EventCast, EventType } from './enums/event.enums';

export default interface EventContract {
    name: string;
    imageUrls: string[];
    description: string;
    dateTime: Date;
    eventType: EventType;
    hallId: number;
    price: number;
    eventCast: EventCast;
    eventState: boolean;
}
