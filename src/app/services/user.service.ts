import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders} from "@angular/common/http";
import {Observable} from "rxjs";
import { User} from "../models/User";

@Injectable({
  providedIn: 'root'
})
export class UserService {
  private usersUrl = 'https://localhost:5001/users/getUsers';

  constructor(private http:HttpClient) { }

  // gets all users -----------------------------------------
  getUsers():Observable<User[]> {
    return this.http.get<User[]>(this.usersUrl);
  }

  // gets one user --------------------------------------
  // getUser(id: number): Observable<User> {
  //   const url = `${this.usersUrl}/${id}`;
  //   return this.http.get<User>(url);
  // }

}
