import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { User } from '../models/users.model'
import { UserSearch } from '../models/userSearch.model';
@Injectable({
  providedIn: 'root'
})
export class UsersService {
  baseApiUrl: string = "https://localhost:7256"
  constructor(private http: HttpClient) { }

  doGetAllEmployees(): Observable<User[]>{
    return this.http.get<User[]>(this.baseApiUrl + '/api/users');
  }

  doInsert(addUserRequest: User): Observable<User>{
    addUserRequest.user_id = '00000000-0000-0000-0000-000000000000';
    return this.http.post<User>(this.baseApiUrl + '/api/users', addUserRequest);
  }

  doGetDetailUser(id:string): Observable<User>{
    return this.http.get<User>(this.baseApiUrl + '/api/users/' + id);
  }

  doUpdate(id: string, updateUserRequest: User): Observable<User>{
    return this.http.put<User>(this.baseApiUrl + '/api/users/' + id, updateUserRequest);
  }

  doDelete(id:string): Observable<User>{
    return this.http.delete<User>(this.baseApiUrl + '/api/Users/' + id)
  }

  doSearchUser(search:string, searchArgs:URLSearchParams): Observable<User[]>{
    return this.http.get<User[]>(this.baseApiUrl + '/api/Users/'+search+'?'+searchArgs)
  }
}
