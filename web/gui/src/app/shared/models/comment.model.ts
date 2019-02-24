export interface IComment {
	id?: string;
	authorName?: string;
	content: string;
	postId: string;
	authorId: string;
	createdDateTime?: string;
	updatedDateTime?: string;
}
