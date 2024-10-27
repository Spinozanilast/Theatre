import { HttpClient } from '@angular/common/http';
import { inject, Injectable } from '@angular/core';
import { EventContract, EventType } from '@data/event.interface';
import { catchError, map, Observable } from 'rxjs';

@Injectable({
    providedIn: 'root',
})
export class EventsService {
    http: HttpClient = inject(HttpClient);

    private apiUrl = 'https://your-theatre-api-url.com';

    // createEvent(eventData: any): Observable<EventContract> {
    //     return this.http
    //         .post<EventContract>(`${this.apiUrl}/events`, eventData)
    //         .pipe(
    //             map((response) => response),
    //             catchError((error) => {
    //                 console.error('Error creating event:', error);
    //                 throw error;
    //             })
    //         );
    // }

    // updateEvent(eventId: string, eventData: any): Observable<any> {
    //     return this.http
    //         .put(`${this.apiUrl}/events/${eventId}`, eventData)
    //         .pipe(
    //             map((response) => response),
    //             catchError((error) => {
    //                 console.error('Error updating event:', error);
    //                 throw error;
    //             })
    //         );
    // }

    // deleteEvent(eventId: string): Observable<any> {
    //     return this.http.delete(`${this.apiUrl}/events/${eventId}`).pipe(
    //         map((response) => response),
    //         catchError((error) => {
    //             console.error('Error deleting event:', error);
    //             throw error;
    //         })
    //     );
    // }

    // getEventsByHallId(hallId: number): Observable<EventContract[]> {
    //     return this.http
    //         .get<EventContract[]>(`${this.apiUrl}/events/by-hall/${hallId}`)
    //         .pipe(
    //             map((response) => response),
    //             catchError((error) => {
    //                 console.error('Error getting events by hall ID:', error);
    //                 throw error;
    //             })
    //         );
    // }

    // getAllEvents(): Observable<EventContract[]> {
    //     return this.http.get<EventContract[]>(`${this.apiUrl}/events`).pipe(
    //         map((response) => response),
    //         catchError((error) => {
    //             console.error('Error getting all events:', error);
    //             throw error;
    //         })
    //     );
    // }

    imageUrl: string =
        'https://i.pinimg.com/564x/46/a6/3d/46a63d02748ff6a4c82a8abe0c0604e7.jpg';
    getAllEvents(): EventContract[] {
        return [
            {
                title: 'Гамлет',
                imageUrl: this.imageUrl,
                description: 'Трагическая пьеса Уильяма Шекспира',
                dateTime: new Date('2024-10-26T20:00:00'),
                eventType: EventType.Drama,
                hallId: 1,
                price: 20.0,
                eventCast: {
                    directors: ['Джон Доу'],
                    actors: ['Джейн Смит', 'Боб Джонсон'],
                    screenWriters: ['Алиса Браун'],
                },
                eventState: true,
            },
            {
                title: 'Щелкунчик',
                imageUrl: this.imageUrl,
                description: 'Классический балет Чайковского',
                dateTime: new Date('2024-12-24T19:00:00'),
                eventType: EventType.Ballet,
                hallId: 2,
                price: 30.0,
                eventCast: {
                    directors: ['Майк Дэвис'],
                    actors: ['Дэвид Ли', 'Сара Тейлор'],
                    screenWriters: ['Кевин Уайт'],
                },
                eventState: true,
            },
            {
                title: 'Звуки музыки',
                imageUrl: this.imageUrl,
                description: 'Мюзикл Роджерса и Хаммерштейна',
                dateTime: new Date('2024-11-15T20:00:00'),
                eventType: EventType.Musical,
                hallId: 3,
                price: 25.0,
                eventCast: {
                    directors: ['Эмили Чен'],
                    actors: ['Дэвид Ли', 'Сара Тейлор'],
                    screenWriters: ['Кевин Уайт'],
                },
                eventState: true,
            },
        ];
    }
}
