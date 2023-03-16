import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class ApiService {
  constructor(public http: HttpClient) {}

  url = 'https://localhost:7215/api/';
  async getAll(Controller: string) {
    console.log(this.url + Controller);
    let response: any;

    await this.http
      .get<any>(this.url + Controller).toPromise().then((res) => {
        response = res
      });
    return response;
  }
}