import { Component, OnInit } from '@angular/core';
import { HackerNewsService } from '../../services/hacker-news.service';
import { Story } from '../../models/story/story.module';

@Component({
  selector: 'app-story-list',
  templateUrl: './story-list.component.html',
  styleUrls: ['./story-list.component.scss']
})
export class StoryListComponent implements OnInit {
  stories: Story[] = [];
  filteredStories: Story[] = [];
  searchText = '';
  page = 1;
  pageSize = 10;

  constructor(private hackerNewsService: HackerNewsService) {}

  ngOnInit() {
    this.loadStories();
  }

  loadStories() {
    this.hackerNewsService.getNewestStories(this.page, this.pageSize).subscribe(data => {
      this.stories = data.filter(story => story.url); // Skip missing URLs
      this.filteredStories = [...this.stories];
    });
  }

  onSearch() {
    const term = this.searchText.toLowerCase();
    this.filteredStories = this.stories.filter(s => s.title?.toLowerCase().includes(term));
  }

  nextPage() {
    this.page++;
    this.loadStories();
  }

  prevPage() {
    if (this.page > 1) {
      this.page--;
      this.loadStories();
    }
  }
}
