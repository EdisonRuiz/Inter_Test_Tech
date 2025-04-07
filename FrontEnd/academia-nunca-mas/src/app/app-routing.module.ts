import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { WelcomeComponent } from './welcome/welcome.component';
import { StudentRegisterComponent } from './student-register/student-register.component';
import { StudentDeleteComponent } from './student-delete/student-delete.component';
import { SubjectListComponent } from './subject-list/subject-list.component';
import { SubjectAssignComponent } from './subject-assign/subject-assign.component';

const routes: Routes = [
  { path: '', component: WelcomeComponent },
  { path: 'register-student', component: StudentRegisterComponent },
  { path: 'delete-student', component: StudentDeleteComponent },
  { path: 'list-subjects', component: SubjectListComponent },
  { path: 'assign-subjects', component: SubjectAssignComponent },
  { path: '**', redirectTo: '' }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }