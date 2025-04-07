import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { StudentService } from './student.service';

export interface Subject {
  name: string;
  code: string;
  credits: number;
  teacher: string;
  isSelected: boolean;
  classmates: string[];
}

export interface SubjectsResponse {
  data: Subject[];
  statusCode: number;
  message: string;
}

@Injectable({
  providedIn: 'root'
})
export class SubjectService {
  constructor(
    private http: HttpClient,
    private studentService: StudentService
  ) {}

  getStudentSubjects(): Observable<SubjectsResponse> {
    const userId = this.studentService.getCurrentUserId();
    if (!userId) {
      throw new Error('No user ID available');
    }
    return this.http.get<SubjectsResponse>(`https://localhost:7060/api/StudentSubject/${userId}`);
  }


  assignSubject(subjectCode: string): Observable<any> {
    const userId = this.studentService.getCurrentUserId();
    if (!userId) {
      return throwError(() => new Error('No user ID available'));
    }

    const requestBody = {
      code: subjectCode,
      idUser: userId
    };

    return this.http.put('https://localhost:7060/api/StudentSubject', requestBody).pipe(
      catchError(error => {
        console.error('Error assigning subject:', error);
        return throwError(() => error);
      })
    );
  }
}