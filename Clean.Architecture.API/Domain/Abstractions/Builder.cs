namespace Clean.Architecture.API.Domain.Abstractions {
    public abstract class Builder<TResult> {
        public virtual TResult Build() {
            SetupValidations();
            return default!;
        }

        protected abstract void SetupValidations();
    }
}
