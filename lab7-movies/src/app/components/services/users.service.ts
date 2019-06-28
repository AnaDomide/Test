import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

import { Observable } from 'rxjs';

@Injectable({ providedIn: 'root' })
export class UsersService {
    public users: any;

    constructor(private http: HttpClient) {
    }

    getAllUsers() : Observable<any> {
        return this.http.get<any>(`https://localhost:44382/api/users`);
    }

    getUserHistoryById(id): Observable<any>{
        const url = `${`https://localhost:44382/api/users/history`}/${id}`;
        return this.http.get<any>(url, id);
    }  

}