import { EventCast } from './enums/event.enums';

export default interface Event {
    id: string;
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

export interface EventType {
    id: number;
    name: string;
}
