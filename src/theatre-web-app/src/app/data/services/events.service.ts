import { HttpClient } from '@angular/common/http';
import { inject, Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { environment } from 'environments/environment.development';
import Event from '@data/event.interfaces';

@Injectable({
    providedIn: 'root',
})
export class EventsService {
    private http = inject(HttpClient);
    private apiUrl = `${environment.apiUrl}/events`;

    createEvent(eventData: any): Observable<Event> {
        return this.http
            .post<Event>(this.apiUrl, eventData)
            .pipe(map((response) => response));
    }

    updateEvent(eventId: string, eventData: any): Observable<any> {
        return this.http
            .put(`${this.apiUrl}/${eventId}`, eventData)
            .pipe(map((response) => response));
    }

    deleteEvent(eventId: string): Observable<any> {
        return this.http
            .delete(`${this.apiUrl}/${eventId}`)
            .pipe(map((response) => response));
    }

    getEventsByHallId(hallId: number): Observable<Event[]> {
        return this.http
            .get<Event[]>(`${this.apiUrl}/by-hall/${hallId}`)
            .pipe(map((response) => response));
    }

    getAllEvents(): Observable<Event[]> {
        return this.http
            .get<Event[]>(this.apiUrl)
            .pipe(map((response) => response));
    }
}
