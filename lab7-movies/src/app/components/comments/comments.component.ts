import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { CommentsService } from '../services/comments.service';

@Component({
  selector: 'app-comments',
  templateUrl: './comments.component.html',
  styleUrls: ['./comments.component.scss']
})
export class CommentsComponent implements OnInit {

    public comments: any = null;
    public commentsFiltrare: any = null;
    public displayedColumns: string[] = ['text', 'idMovie', 'important'];

  constructor(private commentsService: CommentsService, private router: Router) {
      this.getAllComments();
    }

  ngOnInit() {

  }

  getAllComments(){
      this.commentsService.getAllComments().subscribe(c => {
          this.comments = c;
          console.log(c);
      })
  }

  filterComment(filter: string){
    this.commentsService.getAllCommentsFiltered(filter).subscribe(c =>{
      this.commentsFiltrare = c;
      console.log(c);
    })

  }


  goBack(){
    this.router.navigate(['']);
  }

}