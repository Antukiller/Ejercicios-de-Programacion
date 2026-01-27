namespace One_Piece_World.Validator.Common;


public interface IValidator<T> {
    T Validate(T item);
}