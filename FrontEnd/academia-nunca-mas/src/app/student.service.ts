import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class StudentService {
  private currentUserId = new BehaviorSubject<number | null>(null);
  currentUserId$ = this.currentUserId.asObservable();

  setCurrentUserId(id: number) {
    this.currentUserId.next(id);
  }

  getCurrentUserId(): number | null {
    return this.currentUserId.value;
  }
}