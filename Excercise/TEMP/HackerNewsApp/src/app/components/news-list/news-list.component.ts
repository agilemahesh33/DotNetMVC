// src/app/components/news-list/news-list.component.ts
import { Component, OnInit } from '@angular/core';
import { HackerNewsService, Story } from '../../services/hacker-news.service';

@Component({
  selector: 'app-news-list',
  templateUrl: './news-list.component.html',
  styleUrls: ['./news-list.component.css']
})
export class NewsListComponent implements OnInit {
  stories: Story[] = [];
  filteredStories: Story[] = [];
  searchTerm = '';
  page = 1;
  pageSize = 10;

  constructor(private hackerNewsService: HackerNewsService) {}

  ngOnInit(): void {
    this.fetchStories();
  }

  fetchStories(): void {
    this.hackerNewsService.getNewestStories(this.page, this.pageSize).subscribe(data => {
      this.stories = data;
      this.filteredStories = data;
    });
  }

  onSearch(): void {
    const term = this.searchTerm.toLowerCase();
    this.filteredStories = this.stories.filter(story =>
      story.title.toLowerCase().includes(term)
    );
  }

  changePage(delta: number): void {
    this.page += delta;
    if (this.page < 1) this.page = 1;
    this.fetchStories();
  }
}
