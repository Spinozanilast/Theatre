export interface EventContract {
    title: string;
    imageUrl: string;
    description: string;
    dateTime: Date;
    eventType: EventType;
    hallId: number;
    price: number;
    eventCast: EventCast;
    eventState: boolean;
}

export enum EventType {
    Drama = 'Драма',
    Commedy = 'Комедия',
    Ballet = 'Балет',
    Musical = 'Мюзикл',
}

export interface EventCast {
    directors?: string[];
    actors?: string[];
    screenWriters?: string[];
}
