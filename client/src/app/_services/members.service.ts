import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { Member } from '../_models/member';

@Injectable({
  providedIn: 'root'
})
export class MembersService {
  baseUrl = environment.apiUrl;
  constructor(private http: HttpClient) { }

  getMembers() {
    return this.http.get<Member[]>(this.baseUrl + 'users')
  }

  getMember(username: string) {
    return this.http.get<Member>(this.baseUrl + 'users/' + username);
  }

  // getHttpOptions() {
  //   const userStirng = localStorage.getItem('user');
  //   if(!userStirng) return;
  //   const user = JSON.parse(userStirng);
  //   return {
  //     headers: new HttpHeaders ({
  //       Authorization: 'Bearer ' + user.token //NOTE: Must have space after 'Bearer' to spit it with token
  //     })
  //   }
  // }
}
