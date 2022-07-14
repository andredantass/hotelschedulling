export class ServiceResult<T> {
    data: T;
    success: boolean;
    message: string;
    codeId: number;
}
