import { Teacher } from './../models/Teacher';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { actions } from '../store/schoolang.constants';

@Injectable({
  providedIn: 'root'
})
export class TeacherService {

  public url = `${environment.webApiUrl}/${actions.webApi.Teacher}`;

  constructor(private http: HttpClient) { }

  getAll(): Observable<Teacher[]>{
    return this.http.get<Teacher[]>(`${this.url}`);
  }

  getById(id: number): Observable<Teacher>{
    return this.http.get<Teacher>(`${this.url}/${id}`);
  }

  post(teacher: Teacher) {
    return this.http.post(`${this.url}`, teacher);
  }

  put(teacher: Teacher) {
    return this.http.put(`${this.url}/${teacher.id}`, teacher);
  }

  delete(id: number) {
    return this.http.delete(`${this.url}/${id}`);
  }
}
