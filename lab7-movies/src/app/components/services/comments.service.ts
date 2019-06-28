import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

import { Observable } from 'rxjs';

@Injectable({ providedIn: 'root' })
export class CommentsService {
    public filme: any;

    constructor(private http: HttpClient) {
    }

    getAllComments() : Observable<any> {
        return this.http.get<any>(`https://localhost:44382/api/comments`);
    }

    getAllCommentsFiltered(filter): Observable<any>{
        const url = `${`https://localhost:44382/api/comments?filterString=`}${filter}`;
        return this.http.get<any>(url, filter);
    }  

}