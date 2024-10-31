export enum EventType {
    Drama = 'Драма',
    Commedy = 'Комедия',
    Ballet = 'Балет',
    Musical = 'Мюзикл',
}

export interface EventCast {
    directors?: string[];
    screenWriters?: string[];
    actors?: string[];
}
