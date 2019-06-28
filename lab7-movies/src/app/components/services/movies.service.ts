import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

import { Movie } from '../models/movie';
import { map } from 'rxjs/operators';
import { BehaviorSubject, Observable } from 'rxjs';

@Injectable({ providedIn: 'root' })
export class MovieService {
    //private moviesSubject: BehaviorSubject<any>;
    public movies: any;

    private movieUrl = 'https://localhost:44382/api/movies?page=';


    constructor(private http: HttpClient) {
        //this.moviesSubject = new BehaviorSubject<any>(null);
    }

    getAllMovies() : Observable<any> {
        return this.http.get<any>(`https://localhost:44382/api/movies`);
    }


    // getAllMovies() : Observable<any> {
    //     return this.http.get<any>(`https://localhost:44382/api/movies`)
    //     .pipe(map(response => {
    //         this.movies = response;
    //         this.moviesSubject.next(this.movies);
    //         return response;
    //     }));
    // }
}