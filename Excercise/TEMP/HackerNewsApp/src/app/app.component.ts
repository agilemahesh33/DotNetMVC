import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';

interface Story {
  id: number;
  title: string;
  url: string;
  by: string;
  score: number;
  time: number;
}

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  stories: Story[] = [];
  filteredStories: Story[] = [];
  searchTerm: string = '';
  page: number = 1;
  pageSize: number = 10;

  constructor(private http: HttpClient) {}

  ngOnInit(): void {
    this.fetchStories();
  }

  fetchStories(): void {
    this.http.get<Story[]>(`http://localhost:5116/api/HackerNews/newest?page=${this.page}&pageSize=${this.pageSize}`)
      .subscribe(data => {
        this.stories = data;
        this.filteredStories = data;
      });
  }

  onSearch(): void {
    const term = this.searchTerm.toLowerCase();
    this.filteredStories = this.stories.filter(story =>
      story.title?.toLowerCase().includes(term)
    );
  }

  nextPage(): void {
    this.page++;
    this.fetchStories();
  }

  prevPage(): void {
    if (this.page > 1) {
      this.page--;
      this.fetchStories();
    }
  }
}
