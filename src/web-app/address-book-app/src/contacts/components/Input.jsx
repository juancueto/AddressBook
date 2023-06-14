import { useFormContext } from 'react-hook-form';

export const Input = ({label, type, id, placeholder, isRequired, name, value}) => {
    const { register, formState } = useFormContext();
    
    const hasError = formState?.errors?.[name];
    let addedStyle = '';
    if(hasError !== undefined){
        addedStyle = hasError ? "is-invalid" : "is-valid";
    }

    return (
        <>
            <label htmlFor={id} className='form-label'>{label}</label>
            <input 
                ref={register}
                id={id}
                className={`form-control ${addedStyle}`} 
                placeholder={placeholder}
                name={name}
                type={type}
                autoComplete='off'
                
                {...register(name, {
                    required: {
                        value: isRequired,
                        message: 'required'
                    },
                })}
                required
            />
        </>
    )
}
