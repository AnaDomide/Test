import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { HomeComponent } from './components/home/home.component';
import { MoviesComponent } from './components/movies/movies.component';
import { UserRoleComponent } from './components/userRole/userRole.component';
import { UsersComponent } from './components/users/users.component';
import { CommentsComponent } from './components/comments/comments.component';

const routes: Routes = [
  {
    path:'',
    component: HomeComponent,
    children:[
      {
        path: 'movies',
        component: MoviesComponent
      },
      {
        path: 'userRoles',
        component: UserRoleComponent
      },
      {
        path: 'users',
        component: UsersComponent
      },
      {
        path: 'comments',
        component: CommentsComponent
      }
    ]
}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }