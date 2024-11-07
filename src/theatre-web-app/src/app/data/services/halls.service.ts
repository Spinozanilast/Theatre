import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { environment } from 'environments/environment.development';
import HallContract from '@data/hall.interfaces';

@Injectable({
    providedIn: 'root',
})
export class HallService {
    private apiUrl = `${environment.apiUrl}/halls`;
    private httpOptions = {
        headers: new HttpHeaders({
            'Content-Type': 'application/json',
            Authorization: 'Bearer ',
        }),
    };

    constructor(private http: HttpClient) {}

    createHall(hall: HallContract): Observable<HallContract> {
        return this.http
            .post<HallContract>(this.apiUrl, hall, this.httpOptions)
            .pipe(map((response) => response));
    }

    updateHall(hallId: number, hall: HallContract): Observable<any> {
        return this.http
            .put(`${this.apiUrl}/${hallId}`, hall, this.httpOptions)
            .pipe(map((response) => response));
    }

    removeHall(hallId: number): Observable<any> {
        return this.http
            .delete(`${this.apiUrl}/${hallId}`, this.httpOptions)
            .pipe(map((response) => response));
    }

    getHall(hallId: number): Observable<HallContract> {
        return this.http
            .get<HallContract>(`${this.apiUrl}/${hallId}`)
            .pipe(map((response) => response));
    }

    getHalls(): Observable<HallContract[]> {
        return this.http
            .get<HallContract[]>(this.apiUrl)
            .pipe(map((response) => response));
    }
}
