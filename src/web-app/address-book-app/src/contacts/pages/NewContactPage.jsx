import { NavLink, useNavigate } from 'react-router-dom';
import { FormProvider, useForm } from 'react-hook-form';

import { postContact } from '../helpers'
import { ContactForm} from '../components'


export const NewContactPage = () => {
    const methods = useForm();

    const navigate = useNavigate();

    const onSaveSubmit = methods.handleSubmit(data => {
        event.preventDefault();
        
        const contact = {...data};
        if(contact.birthday === ''){
            contact.birthday = null;
        }

        postContact(contact).then((response) => {
            alert('The contact was registered');
            navigate('/contacts');
        });
    });

    return (
        <>
            <div className='col-8'>
                <div className='card shadow'>
                    <div className='card-body'>
                        <h3 className='card-title'>New Contact</h3>
                        <hr/>
                        <FormProvider {...methods}>
                            <form onSubmit={onSaveSubmit} noValidate>
                                <ContactForm></ContactForm>

                                <hr/>
                                
                                <div className='mt-3'>
                                    <div className="row">
                                        <div className="col-2">
                                            <button type="submit" className="btn btn-outline-primary"            
                                                >
                                                Save
                                            </button>
                                        </div>
                                        <div className="col-2">
                                            <NavLink className="btn btn-primary"
                                                to='/contacts'>
                                                Cancel
                                            </NavLink>
                                        </div>
                                    </div>
                                </div>
                            </form>
                        </FormProvider>
                    </div>
                </div>
            </div>
        </>
    )
}
