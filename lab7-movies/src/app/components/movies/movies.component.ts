import { Component, OnInit, ViewChild } from '@angular/core';
import { Router } from '@angular/router';
import { MovieService } from '../services/movies.service';

@Component({
  selector: 'app-movies',
  templateUrl: './movies.component.html',
  styleUrls: ['./movies.component.scss']
})
export class MoviesComponent implements OnInit {

    public movies: any = null;
    public displayedColumns: string[] = ['title', 'description',
                                         'genre', 'dateAdded', 
                                         'duration', 'releaseYear',
                                        'director', 'rating',
                                        'watched', 'numberOfComments'];


  constructor(private moviesService: MovieService, private router: Router) {
      this.getAllMovies();
    }

  ngOnInit() {    
  }


  getAllMovies(){
    this.moviesService.getAllMovies().subscribe(m => {
        this.movies = m;
        
        console.log(m);          
    })
}

  goBack(){
    this.router.navigate(['']);
  }

}