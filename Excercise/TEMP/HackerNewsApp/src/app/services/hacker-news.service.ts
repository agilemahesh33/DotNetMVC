// src/app/services/hacker-news.service.ts
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

export interface Story {
  id: number;
  title: string;
  url?: string;
  by: string;
  score: number;
}

@Injectable({
  providedIn: 'root'
})
export class HackerNewsService {
  private baseUrl = 'http://localhost:5116/api/HackerNews';

  constructor(private http: HttpClient) {}

  getNewestStories(page: number = 1, pageSize: number = 20): Observable<Story[]> {
    return this.http.get<Story[]>(`${this.baseUrl}/newest?page=${page}&pageSize=${pageSize}`);
  }
}
