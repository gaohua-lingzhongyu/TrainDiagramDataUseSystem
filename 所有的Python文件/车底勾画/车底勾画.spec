# -*- mode: python -*-

block_cipher = None


a = Analysis(['C:\\Users\\����١���\\AppData\\Local\\Programs\\Python\\Python36\\Lib\\site-packages\\PyInstaller\\���׹���\\���׹���.py'],
             pathex=['C:\\Users\\����١���\\AppData\\Local\\Programs\\Python\\Python36\\Lib\\site-packages\\PyInstaller\\���׹���'],
             binaries=[],
             datas=[],
             hiddenimports=[],
             hookspath=[],
             runtime_hooks=[],
             excludes=[],
             win_no_prefer_redirects=False,
             win_private_assemblies=False,
             cipher=block_cipher)
pyz = PYZ(a.pure, a.zipped_data,
             cipher=block_cipher)
exe = EXE(pyz,
          a.scripts,
          a.binaries,
          a.zipfiles,
          a.datas,
          name='���׹���',
          debug=False,
          strip=False,
          upx=True,
          runtime_tmpdir=None,
          console=True )
