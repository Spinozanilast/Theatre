import { HttpClient, HttpHeaders } from '@angular/common/http';
import { inject, Injectable } from '@angular/core';
import SeatContract, {
    SeatTypeMultiplier,
    Sectors,
} from '@data/seat.interfaces';
import { environment } from 'environments/environment.development';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';

@Injectable({
    providedIn: 'root',
})
export default class SeatsService {
    http: HttpClient = inject(HttpClient);

    private apiUrl = `${environment.apiUrl}/seats`;

    private httpOptions = {
        headers: new HttpHeaders({ 'Content-Type': 'application/json' }),
    };

    createSeat(seat: any): Observable<SeatContract> {
        return this.http
            .post<SeatContract>(this.apiUrl, seat, this.httpOptions)
            .pipe(map((response) => response));
    }

    updateSeat(seatId: number, seat: any): Observable<any> {
        return this.http
            .put(`${this.apiUrl}/${seatId}`, seat, this.httpOptions)
            .pipe(map((response) => response));
    }

    removeSeat(seatId: number): Observable<any> {
        return this.http
            .delete(`${this.apiUrl}/${seatId}`)
            .pipe(map((response) => response));
    }

    getSeat(seatId: number): Observable<SeatContract> {
        return this.http
            .get<SeatContract>(`${this.apiUrl}/${seatId}`)
            .pipe(map((response) => response));
    }

    getSeatsBySectorId(sectorId: number): Observable<SeatContract[]> {
        return this.http
            .get<SeatContract[]>(`${this.apiUrl}/by-sector/${sectorId}`)
            .pipe(map((response) => response));
    }

    getGroupedSeatsGroupedByHallId(hallId: number): Observable<Sectors[]> {
        return this.http
            .get<Sectors[]>(`${this.apiUrl}/by-hall/${hallId}`)
            .pipe(map((response) => response));
    }

    getSeatTypeMultipliersSet(sectors: Sectors[]) {
        const seatTypeMultipliersSet = new Set<string>();

        sectors.forEach((sector) => {
            sector.rows.forEach((row) => {
                row.seats.forEach((seat) => {
                    seatTypeMultipliersSet.add(
                        seat.seatTypeMultiplier.seatType
                    );
                });
            });
        });

        return seatTypeMultipliersSet;
    }
}
