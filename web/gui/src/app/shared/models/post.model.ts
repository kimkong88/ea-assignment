import { IAuthor } from './author.model';

export interface IPost {
	id: string;
	title: string;
	content: string;
	author: IAuthor;
	createdAt: string;
	updatedAt: string;
}
