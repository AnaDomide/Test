import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})
export class HomeComponent implements OnInit {

  constructor(
    private router: Router,
  ) {

    }

  ngOnInit() {
    // const currentRoute = this.router.url;

    // if (currentRoute === '/users') {
    //   this.router.navigate(['/users']);
    // } else {
    //   this.router.navigate(['/flowers']);
    // }
  }

  home() {
    this.router.navigate(['']);
  }

  usersManagement() {
    this.router.navigate(['/users']);
  }

  userRoleManagement() {
    this.router.navigate(['/userRoles']);
  }

  moviesManagement() {
    this.router.navigate(['/movies']);
  }

  commentsManagement() {
    this.router.navigate(['/comments']);
  }

  logout() {
  }
}