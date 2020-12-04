import { Student } from './../models/Student';
import { environment } from './../../environments/environment';
import { actions } from './../store/schoolang.constants';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class StudentService {

  public getStudent = `${environment.webApiUrl}/${actions.webApi.getStudent}`;

  constructor(private http: HttpClient) { }

  getAll(): Observable<Student[]>{
    return this.http.get<Student[]>(`${this.getStudent}`);
  }

  getById(id: number): Observable<Student>{
    return this.http.get<Student>(`${this.getStudent}/${id}`);
  }
}
