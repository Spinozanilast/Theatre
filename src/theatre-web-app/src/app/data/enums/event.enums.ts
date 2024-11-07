export enum EventType {
    Drama = 'Драма',
    Commedy = 'Комедия',
    Ballet = 'Балет',
    Musical = 'Мюзикл',
    Opera = 'Опера',
}

export interface EventCast {
    directors?: string[];
    screenWriters?: string[];
    actors?: string[];
}
