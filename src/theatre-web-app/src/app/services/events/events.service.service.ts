import { HttpClient } from '@angular/common/http';
import { inject, Injectable } from '@angular/core';
import EventContract from '@data/event.interfaces';
import { catchError, map, Observable } from 'rxjs';

@Injectable({
    providedIn: 'root',
})
export default class EventsService {
    http: HttpClient = inject(HttpClient);

    private apiUrl = 'http://localhost:5138';

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

    getAllEvents(): Observable<EventContract[]> {
        return this.http.get<EventContract[]>(`${this.apiUrl}/events`).pipe(
            map((response) => response),
            catchError((error) => {
                console.error('Error getting all events:', error);
                throw error;
            })
        );
    }
}
