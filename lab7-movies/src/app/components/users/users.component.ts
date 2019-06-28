import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { UsersService } from '../services/users.service';

@Component({
  selector: 'app-users',
  templateUrl: './users.component.html',
  styleUrls: ['./users.component.scss']
})
export class UsersComponent implements OnInit {

    public users: any = null;
    public history: any = null;
    public displayedColumns: string[] = ['firstName', 'lastName', 'userName', 'email'];
    public displayedColumnsHistory: string[] = ['userRoleName', 'startTime', 'endTime'];


  constructor(private usersService: UsersService, private router :Router) {
      this.getAllUsers();
  }

  ngOnInit() {

  }

  getAllUsers(){
      this.usersService.getAllUsers().subscribe(u => {
          this.users = u;
          console.log(u);
      })
  }

  getHistory(id){
    this.usersService.getUserHistoryById(id).subscribe(ur => {
      this.history = ur;
      console.log(ur)
    })
  }


  goBack(){
    this.router.navigate(['']);
  }

}