def encode_message(message):
    encoded_message = []
    vowels = 'AEIOU'
    consonants = 'BCDFGHJKLMNPQRSTVWXYZ'

    for char in message.upper():
        if char in vowels:
            # Move each vowel back one
            index = vowels.index(char)
            encoded_message.append(vowels[index - 1])
        elif char in consonants:
            # Move each consonant forward one
            index = consonants.index(char)
            encoded_message.append(consonants[(index + 1) % len(consonants)])
        else:
            # Leave non-alphabetic characters unchanged
            encoded_message.append(char)
    
    return ''.join(encoded_message)

def decode_message(message):
    decoded_message = []
    vowels = 'AEIOU'
    consonants = 'BCDFGHJKLMNPQRSTVWXYZ'

    for char in message.upper():
        if char in vowels:
            # Move each vowel forward one
            index = vowels.index(char)
            decoded_message.append(vowels[(index + 1) % len(vowels)])
        elif char in consonants:
            # Move each consonant backward one
            index = consonants.index(char)
            decoded_message.append(consonants[index - 1])
        else:
            # Leave non-alphabetic characters unchanged
            decoded_message.append(char)
    
    return ''.join(decoded_message)

def main():
    choice = input("Do you want to encode or decode a message? (encode/decode): ").lower()
    
    if choice == "encode":
        message = input("Enter the message to encode: ")
        encoded_message = encode_message(message)
        print(f"Encoded message: {encoded_message}")
    elif choice == "decode":
        message = input("Enter the message to decode: ")
        decoded_message = decode_message(message)
        print(f"Decoded message: {decoded_message}")
    else:
        print("Invalid choice. Please enter 'encode' or 'decode'.")

if __name__ == "__main__":
    main()
