import { ProfileComponent } from './components/profile/profile.component';
import { StudentComponent } from './components/student/student.component';
import { TeachersComponent } from './components/teacher/teachers.component';
import { DashboardComponent } from './dashboard/dashboard.component';

import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';


const routes: Routes = [
  { path: '', redirectTo: 'dashboard', pathMatch: 'full' },
  { path: 'dashboard', component: DashboardComponent },
  { path: 'professores', component: TeachersComponent },
  { path: 'alunos', component: StudentComponent },
  { path: 'perfil', component: ProfileComponent },
  { path: 'professores', component: TeachersComponent },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
