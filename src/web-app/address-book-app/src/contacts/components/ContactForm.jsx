import { Input }  from './Input';

export const ContactForm = () => {
    return (
        <>      
            <div className='mt-3'>
                <Input 
                    id='firstName'
                    label='First name:'
                    placeholder='First name'
                    type='text'
                    name='firstName'
                    isRequired={true}
                />
            </div>
            <div className='mt-3'>
                <Input 
                    id='lastName'
                    label='Last name:'
                    placeholder='Last name'
                    type='text'
                    name='lastName'
                    isRequired={true}
                />
            </div>
            <div className='mt-3'>
                <Input 
                    id='phoneNumber'
                    label='Phone number:'
                    placeholder='123 456-7890'
                    type='text'
                    name='phoneNumber'
                    isRequired={true}
                />
            </div>
            <div className='mt-3'>
                <Input 
                    id='physicalAddress'
                    label='Address:'
                    placeholder='Address'
                    type='text'
                    name='physicalAddress'
                    isRequired={false}
                />
            </div>
            <div className='mt-3'>
                <Input 
                    id='birthday'
                    label='Birthday:'
                    placeholder='1/1/2020'
                    type='date'
                    name='birthday'
                    isRequired={false}
                />
            </div>            
            <div className='mt-3'>
                <Input 
                    id='email'
                    label='Email Address:'
                    placeholder='name@example.com'
                    type='text'
                    name='email'
                    isRequired={false}
                />
            </div>

            <div className='mt-3'>
                <Input 
                    id='companyName'
                    label='Company:'
                    placeholder='Company'
                    type='text'
                    name='companyName'
                    isRequired={false}
                />
            </div>
        </>
    )
}
