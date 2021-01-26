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

  public url = `${environment.webApiUrl}/${actions.webApi.Student}`;

  constructor(private http: HttpClient) { }

  getAll(): Observable<Student[]>{
    return this.http.get<Student[]>(`${this.url}`);
  }

  getById(id: number): Observable<Student>{
    return this.http.get<Student>(`${this.url}/${id}`);
  }

  post(student: Student) {
    return this.http.post(`${this.url}`, student);
  }

  put(student: Student) {
    return this.http.put(`${this.url}/${student.id}`, student);
  }

  delete(id: number) {
    return this.http.delete(`${this.url}/${id}`);
  }
}
