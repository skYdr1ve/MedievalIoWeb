import { Injectable } from '@angular/core';
import { ApiService } from "./api.service";
import { UserModel } from "../../models/user.model";
import { Observable } from 'rxjs';

@Injectable()
export class StatisticsService {
  constructor(private http: ApiService) {
  }

  getStatistics(filter: string) : Observable<UserModel[]>{
    return this.http.get<UserModel[]>(`Statistics/GetStatistics?filter=${filter}`);
  }
}
