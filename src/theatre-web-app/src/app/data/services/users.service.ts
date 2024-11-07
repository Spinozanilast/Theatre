import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { catchError, map } from 'rxjs/operators';
import { environment } from 'environments/environment.development';
import User, { UserData } from '@data/user.interfaces';

@Injectable({
    providedIn: 'root',
})
export class UserService {
    private apiUrl = `${environment.apiUrl}/users`;
    private httpOptions = {
        headers: new HttpHeaders({
            'Content-Type': 'application/json',
            Authorization: 'Bearer ', // Add your token if needed
        }),
    };

    constructor(private http: HttpClient) {}

    createUser(user: UserData): Observable<User> {
        return this.http
            .post<User>(this.apiUrl, user, this.httpOptions)
            .pipe(map((response) => response));
    }

    updateUser(userId: number | string, user: User): Observable<any> {
        return this.http
            .put(`${this.apiUrl}/${userId}`, user, this.httpOptions)
            .pipe(map((response) => response));
    }

    deleteUser(userId: number | string): Observable<any> {
        return this.http
            .delete(`${this.apiUrl}/${userId}`, this.httpOptions)
            .pipe(map((response) => response));
    }

    getUser(userId: number | string): Observable<User> {
        return this.http
            .get<User>(`${this.apiUrl}/${userId}`)
            .pipe(map((response) => response));
    }

    getUsers(): Observable<User[]> {
        return this.http
            .get<User[]>(this.apiUrl)
            .pipe(map((response) => response));
    }

    getUserByPhoneNumber(phoneNumber: string): Observable<User> {
        return this.http
            .get<User>(`${this.apiUrl}/by-phone/${phoneNumber}`)
            .pipe(map((response) => response));
    }
}
